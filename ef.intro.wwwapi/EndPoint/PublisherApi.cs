using ef.intro.wwwapi.Models;
using ef.intro.wwwapi.Repository;

namespace ef.intro.wwwapi.EndPoint
{
    public static class PublisherApi
    {
        public static void ConfigurePublisherApi(this WebApplication app)
        {
            app.MapGet("/publisher", GetPublishers);
            app.MapGet("/publisher/{id}", GetAPublisher);
            app.MapPost("/publisher", InsertPublisher);
            app.MapPut("/publisher", UpdatePublisher);
            app.MapDelete("/publisher", DeletePublisher);
        }
        private static async Task<IResult> GetPublishers(ILibraryRepository service)
        {
            try
            {
                return await Task.Run(() => {
                    return Results.Ok(service.GetAllPublishers());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetAPublisher(int id, ILibraryRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var person = service.GetAPublisher(id);
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertPublisher(Publisher publisher, ILibraryRepository service)
        {
            try
            {
                if (service.AddPublisher(publisher)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdatePublisher(Publisher publisher, ILibraryRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdatePublisher(publisher)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeletePublisher(int id, ILibraryRepository service)
        {
            try
            {
                if (service.DeletePublisher(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
