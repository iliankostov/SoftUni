namespace DistanceCalculatorSOAPService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(VectorPoint start, VectorPoint end);
    }
}