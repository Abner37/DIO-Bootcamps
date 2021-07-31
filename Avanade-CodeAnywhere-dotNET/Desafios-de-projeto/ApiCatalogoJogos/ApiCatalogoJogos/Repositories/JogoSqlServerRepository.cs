using ApiCatalogoJogos.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoSqlServerRepository : IJogoRepository
    {
        private readonly SqlConnection connection;


        public JogoSqlServerRepository(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("Default"));
        }


        public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            var jogos = new List<Jogo>();

            var sqlString = $"SELECT * FROM JOGOS ORDER BY ID OFFSET {(pagina - 1) * quantidade} ROWS FETCH NEXT {quantidade} ROWS ONLY";

            await connection.OpenAsync();

            var command = new SqlCommand(sqlString, connection);
            var dr = await command.ExecuteReaderAsync();

            while (dr.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)dr["id"],
                    Nome = Convert.ToString(dr["nome"]),
                    Produtora = Convert.ToString(dr["produtora"]),
                    Preco = Convert.ToDouble(dr["preco"])
                });
            }

            await connection.CloseAsync();

            return jogos;
        }
        public async Task<Jogo> Obter(Guid id)
        {
            Jogo jogo = null;

            var sqlString = $"SELECT * FROM JOGOS WHERE id = '{id}'";

            await connection.OpenAsync();

            var command = new SqlCommand(sqlString, connection);
            var dr = await command.ExecuteReaderAsync();

            if (dr.Read())
            {
                jogo = new Jogo
                {
                    Id = (Guid)dr["id"],
                    Nome = Convert.ToString(dr["nome"]),
                    Produtora = Convert.ToString(dr["produtora"]),
                    Preco = Convert.ToDouble(dr["preco"])
                };
            }

            await connection.CloseAsync();

            return jogo;
        }
        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            var jogos = new List<Jogo>();

            var sqlString = $"SELECT * FROM JOGOS WHERE NOME = '{nome}' AND PRODUTORA = '{produtora}'";

            await connection.OpenAsync();

            var command = new SqlCommand(sqlString, connection);
            var dr = await command.ExecuteReaderAsync();

            while (dr.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)dr["id"],
                    Nome = Convert.ToString(dr["nome"]),
                    Produtora = Convert.ToString(dr["produtora"]),
                    Preco = Convert.ToDouble(dr["preco"])
                });
            }

            await connection.CloseAsync();

            return jogos;
        }
        public async Task Inserir(Jogo jogo)
        {
            var sqlString = $"INSERT INTO JOGOS (ID, NOME, PRODUTORA, PRECO) VALUES ('{jogo.Id}', '{jogo.Nome}', '{jogo.Produtora}', {jogo.Preco.ToString().Replace(",", ".")})";

            await connection.OpenAsync();

            var command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();

            await connection.CloseAsync();
        }
        public async Task Atualizar(Jogo jogo)
        {
            var sqlString = $"UPDATE JOGOS SET NOME = '{jogo.Nome}', PRODUTORA = '{jogo.Produtora}', PRECO = {jogo.Preco.ToString().Replace(",", ".")} WHERE ID = '{jogo.Id}'";

            await connection.OpenAsync();

            var command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();

            await connection.CloseAsync();
        }
        public async Task Remover(Guid id)
        {
            var sqlString = $"DELETE FROM JOGOS WHERE ID = '{id}'";

            await connection.OpenAsync();

            var command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();

            await connection.CloseAsync();
        }

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
