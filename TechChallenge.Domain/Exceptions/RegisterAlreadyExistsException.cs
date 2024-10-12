using System.Net;

namespace TechChallenge.Domain.Exceptions
{
    public class RegisterAlreadyExistsException : BaseException
    {
        public RegisterAlreadyExistsException() : base("Já existe um registro com esses parâmetros.", HttpStatusCode.Conflict) { }
        public RegisterAlreadyExistsException(string message) : base(message, HttpStatusCode.Conflict) { }
        public RegisterAlreadyExistsException(string parameterName, string parameterValue) : base($"Já existe um registro com o parâmetro {parameterName} igual à {parameterValue}.", HttpStatusCode.Conflict) { }
    }
}
