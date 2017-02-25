namespace Chepelare
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using Chepelare.Contracts;
    using Chepelare.Data;
    using Chepelare.Infrastructure;
    using Chepelare.Models;
    using Chepelare.Utilities;
    using Chepelare.Views.Shared;

    using HotelBookingSystem.Infrastructure;

    public class Engine : IEngine
    {
        public void StartOperation()
        {
            var database = new HotelBookingSystemData();
            User currentUser = null;
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType =
                    Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);
                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;
                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                object[] parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    viewResult = new Error(ex.InnerException.Message).Display();
                }

                Console.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action.GetParameters().Select<ParameterInfo, object>(
                p =>
                    {
                        if (p.ParameterType == typeof(int))
                        {
                            return int.Parse(executionEndpoint.Parameters[p.Name]);
                        }
                        else if (p.ParameterType == typeof(decimal))
                        {
                            return decimal.Parse(executionEndpoint.Parameters[p.Name]);
                        }
                        else if (p.ParameterType == typeof(DateTime))
                        {
                            var date = DateTime.ParseExact(
                                executionEndpoint.Parameters[p.Name],
                                Constants.DateFormat,
                                CultureInfo.InvariantCulture);

                            return date;
                        }
                        else
                        {
                            return executionEndpoint.Parameters[p.Name];
                        }
                    }).ToArray();

            return parameters;
        }
    }
}