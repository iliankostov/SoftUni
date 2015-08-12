namespace DistanceCalculatorSOAPService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(int startX, int startY, int endX, int endY);
    }
}