using AutoMapper;
using FazendaApp.Dados;
using FazendaApp.Domain.Model;
using FazendaApp.Domain.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FazendaApp.Services
{
  public class CategoriaOficialService : ICategoriaOficialService
  {
    private IMapper mapper;
    private readonly HttpClient _client;

    public CategoriaOficialService(HttpClient client)
    {
      _client = client;

      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<CategoriaOficial, CategoriaOficialModel>()
            .ForMember(dto => dto.ID, map => map.MapFrom(source => source.ID.ToString()))
            .ForMember(dto => dto.ValorMinimo, map => map.MapFrom(source => source.ValorMinimo.ToString()))
            .ForMember(dto => dto.ValorMaximo, map => map.MapFrom(source => source.ValorMaximo.ToString()));
      });

      mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<CategoriaOficialModel>> GetAsync()
    {
      var httpResponse = await _client.GetAsync("http://homologacao.service.mergefusao.agrohub.com.br/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2");

      if (!httpResponse.IsSuccessStatusCode)
      {
        throw new Exception("Não foi possivel realizar a transação");
      }

      var resposta = await httpResponse.Content.ReadAsStringAsync();
      var lista = JsonConvert.DeserializeObject<ListaCategorias>(resposta);

      return mapper.Map<IEnumerable<CategoriaOficial>, IEnumerable<CategoriaOficialModel>>(lista.ObterPorEstadoFazendaResult);
    }
  }
}
