namespace MedicalIS.Application.Exceptions
{
    public class NotFoundException(string name, object key) : Exception($"{name} with key {key} wasn't found.")
    {
    }
}
