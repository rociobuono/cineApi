using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Diagnostics;
 
namespace ATDapi.Controllers;

[ApiController]

public class CarteleraController : ControllerBase
{
    public static List<CarteleraModel> DataLista = new List<CarteleraModel>();

    public static int  id = 0; 
   [HttpGet]
   [Route("CarteleraController/Get")]
   public BaseResponse Get()
    {
        return new DataResponse<List<CarteleraModel>>(true,(int)HttpStatusCode.OK,"Lista de Pelicula",DataLista);
    }

    [HttpPost]
    [Route("CarteleraController/Create")]
    public BaseResponse Post([FromBody]CarteleraModel dataInput)
    {
        id++;
        dataInput.id = id;
        DataLista.Add(dataInput);
        return new BaseResponse (true,(int)HttpStatusCode.Created, "Hola :D"); 
    }
    [HttpDelete]
    [Route("CarteleraController/Delete")]
    public BaseResponse Delete([FromQuery]int id)
    {
        CarteleraModel? peli = DataLista.FirstOrDefault(x => x.id == id);

        if (peli == null)
        {
            return new BaseResponse(false,(int)HttpStatusCode.NotFound,"No se encontro la pelicula");
        }
        else{
            DataLista.Remove(peli);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Pelicula eliminada correctamente");
        }
    }

    [HttpPatch]
    [Route("CarteleraController/Patch")]
    public BaseResponse Patch([FromBody]CarteleraModel dataInput)
    {
        if (dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "No se encontro el id");
        }

        CarteleraModel? peli = DataLista.FirstOrDefault(x => x.id == dataInput.id);
        if (peli == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "No se encontro la pelicula");
        }
        else
        {
            DataLista.Remove(peli);
            DataLista.Add(dataInput);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Pelicula actualizada correctamente");
        }

    }


    [HttpPut]
    [Route("CarteleraController/Put")]
    public BaseResponse Put([FromBody]CarteleraModel dataInput)
    {
        if(dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "No se encontro el id");
        }

        CarteleraModel? peli = DataLista.FirstOrDefault(x => x.id == dataInput.id);

        if(peli == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "La pelicula no fue encontrada");
        }
        else
        {
            DataLista.Remove(peli);
            if(dataInput.titulo != null)
            {
                peli.titulo = dataInput.titulo;
            }
            if(dataInput.sinopsis != null)
            {
                peli.sinopsis = dataInput.sinopsis;
            }
            if(dataInput.url != null)
            {
                peli.url = dataInput.url;
            }
            if(dataInput.genero != null)
            {
                peli.genero = dataInput.genero;
            }
            if(dataInput.duracion != null)
            {
                peli.duracion = dataInput.duracion;
            }
            if(dataInput.director != null)
            {
                peli.director = dataInput.director;
            }
            if(dataInput.actores != null)
            {
                peli.actores = dataInput.actores;
            }
            if(dataInput.publico != null)
            {
                peli.publico = dataInput.publico;
            }

            DataLista.Add(peli);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Pelicula modificada");
        }
    }
}
