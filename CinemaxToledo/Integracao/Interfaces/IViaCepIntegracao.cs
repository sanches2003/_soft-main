﻿using CompusoftAtendimento.Integracao.Response;

namespace CompusoftAtendimento.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {

        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
