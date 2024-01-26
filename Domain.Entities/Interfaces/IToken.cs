using SegurancaTrabalho.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SegurancaTrabalho.BusinessEntities.Entities;

namespace SegurancaTrabalho.Domain.Entities.Interfaces
{
    public interface IToken : IGeneric<Token_Entity>
    {
        Token_Entity GerarToken(string Login, string Senha, string appLogin, string appSenha, string appSecrect);
    }
}

