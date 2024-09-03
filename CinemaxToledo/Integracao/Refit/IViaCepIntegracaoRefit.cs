﻿using CompusoftAtendimento.Integracao.Response;
using Refit;

namespace CompusoftAtendimento.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {

        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
