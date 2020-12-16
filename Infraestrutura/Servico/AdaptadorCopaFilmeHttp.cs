using System;
using System.Collections.Generic;
using System.Net.Http;
using Dominio;

namespace Infraestrutura.Servico
{
  public class AdaptadorCopaFilmeHttp
  {
    public static List<Filme> Obter()
    {
      List<Filme> filmes;
      using (var httpClient = new HttpClient())
      {
        var resposta = httpClient.GetAsync("http://copafilmes.azurewebsites.net/api/filmes").Result;
        filmes = resposta.Content.ReadAsAsync<List<Filme>>().Result;
      }
      return filmes;
    }
  }
}
