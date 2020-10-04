using System;
using System.Collections.Generic;
using System.Data;
using Football.Api.Models;

namespace Football.Api.Repositories.Extensions
{
    public static class EnumerableExtensions
    {
        public static DataTable ToDataTable(this IEnumerable<Team> teams)
        {
            var dt = new DataTable();

            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Tla", typeof(string));
            dt.Columns.Add("ShortName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("AreaName", typeof(string));

            foreach (var team in teams)
            {
                dt.Rows.Add(team.Code, team.Name, team.Tla, team.ShortName, team.Email, team.AreaName);
            }

            return dt;
        }

        public static DataTable ToDataTable(this IEnumerable<Player> players)
        {
            var dt = new DataTable();

            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Position", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dt.Columns.Add("CountryOfBirth", typeof(string));
            dt.Columns.Add("Nationality", typeof(string));

            foreach (var player in players)
            {
                dt.Rows.Add(player.Code, player.Name, player.Position, player.DateOfBirth,
                    player.CountryOfBirth, player.Nationality);
            }

            return dt;
        }
    }
}
