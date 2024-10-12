using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("Registro não encontrado.", HttpStatusCode.NotFound){ }
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound){ }
        public NotFoundException(string parameterName, string parameterValue) : base($"Não foi encontrado nenhum registro com o parâmetro {parameterName} igual à {parameterValue}.", HttpStatusCode.NotFound){ }
    }
}
