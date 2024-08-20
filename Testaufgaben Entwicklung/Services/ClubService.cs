using System;
using Microsoft.Data.SqlClient;
using Testaufgaben_Entwicklung.Models;

namespace Testaufgaben_Entwicklung.Services
{
	public class ClubService
	{
        private readonly string _connectionString;

        public ClubService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Club>> GetClubsAsync()
        {
            var clubs = new List<Club>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT ClubName, YearEstablished, League, Country FROM dbo.fnGet_Clubs()";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var club = new Club
                            {
                                ClubName = reader["ClubName"].ToString(),
                                YearEstablished = int.Parse(reader["YearEstablished"].ToString()),
                                League = reader["League"].ToString(),
                                Country = reader["Country"].ToString()
                            };

                            clubs.Add(club);
                        }
                    }
                }
            }

            return clubs;
        }

        public async Task<IEnumerable<Club>> GetClubsByLeagueAsync(int yearEstablished)
        {
            var clubs = new List<Club>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT ClubName, YearEstablished, League, Country FROM dbo.fnGet_ClubsByLeague() WHERE YearEstablished >= @Year";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Year", yearEstablished);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var club = new Club
                            {
                                ClubName = reader["ClubName"].ToString(),
                                YearEstablished = int.Parse(reader["YearEstablished"].ToString()),
                                League = reader["League"].ToString(),
                                Country = reader["Country"].ToString()
                            };

                            clubs.Add(club);
                        }
                    }
                }
            }

            return clubs;
        }
    }
}

