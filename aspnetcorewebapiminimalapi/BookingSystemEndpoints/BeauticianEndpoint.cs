using aspnetcorewebapiminimalapi.Models;
using aspnetcorewebapiminimalapi.Models3;
using DataLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetcorewebapiminimalapi.GlobalVariables;

namespace aspnetcorewebapiminimalapi.Endpoints
{
    public static class BeauticianEndpoint
    {
        public static void BeauticianEndpoints(this WebApplication app)
        {
            //app.MapGet("/products/{id}", (int id) => { return Results.Ok(); });
            app.MapGet("/beauticians", async ([FromServices] IDataAccess _dataAccess) =>
            {
                var sql = "select * from beauticians";
                var res = await _dataAccess.LoadData<Beautician, dynamic>(sql, new { }, GlobalVariables.GlobalVariables.MYSQLCONNECTIONSTRING);
                return res;
            }).RequireCors("_myAllowSpecificOrigins");
        }
    }
}
