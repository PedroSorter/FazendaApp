using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FazendaApp.Domain.Model
{
  public class CategoriaOficialModel
  {
    [JsonProperty("ID")]
    public string ID { get; set; }
    [JsonProperty("Nome")]
    public string Nome { get; set; }
    [JsonProperty("Sexo")]
    public string Sexo { get; set; }
    [JsonProperty("UF")]
    public string UF { get; set; }
    [JsonProperty("ValorMinimo")]
    public string ValorMinimo { get; set; }
    [JsonProperty("ValorMaximo")]
    public string ValorMaximo { get; set; }
  }
}
