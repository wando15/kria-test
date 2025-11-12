using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure.ConfigurationRoot;

public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        // Define o nome da coleção no MongoDB
        builder.ToCollection("TabTransacoes");

        // Define a chave primária
        builder.HasKey(o => o.Id);
        //builder.Property(o => o.IdTransacao).HasField("IdTransacao");
        //builder.Property(o => o.DtCriacao).HasField("DtCriacao");
        //builder.Property(o => o.CodigoPracaPedagio).HasField("CodigoPracaPedagio");
        //builder.Property(o => o.CodigoCabine).HasField("CodigoCabine");
        //builder.Property(o => o.Instante).HasField("Instante");
        //builder.Property(o => o.Sentido).HasField("Sentido");
        //builder.Property(o => o.QuantidadeEixosVeiculo).HasField("QuantidadeEixosVeiculo");
        //builder.Property(o => o.Rodagem).HasField("Rodagem");
        //builder.Property(o => o.Isento).HasField("Isento");
        //builder.Property(o => o.MotivoIsencao).HasField("MotivoIsencao");
        //builder.Property(o => o.Evasao).HasField("Evasao");
        //builder.Property(o => o.EixoSuspenso).HasField("EixoSuspenso");
        //builder.Property(o => o.QuantidadeEixosSuspensos).HasField("QuantidadeEixosSuspensos");
        //builder.Property(o => o.TipoCobranca).HasField("TipoCobranca");
        //builder.Property(o => o.Placa).HasField("Placa");
        //builder.Property(o => o.LiberacaoCancela).HasField("LiberacaoCancela");
        //builder.Property(o => o.ValorDevido).HasField("ValorDevido");
        //builder.Property(o => o.ValorArrecadado).HasField("ValorArrecadado");
        //builder.Property(o => o.CnpjAmap).HasField("CnpjAmap");
        //builder.Property(o => o.MultiplicadorTarifa).HasField("MultiplicadorTarifa");
        //builder.Property(o => o.VeiculoCarregado).HasField("VeiculoCarregado");
        //builder.Property(o => o.IdTag).HasField("IdTag");
    }   
}       
        