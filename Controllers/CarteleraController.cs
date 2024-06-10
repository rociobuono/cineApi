using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Diagnostics;
using ATDapi.Repositories;

namespace ATDapi.Controllers;

[ApiController]

public class CarteleraController : ControllerBase
{

    private Repository repository = new Repository();
    private CarteleraModel carteleraModel = new CarteleraModel();
    string nombre = "Cartelera";
    public static List<CarteleraModel> DataLista = new List<CarteleraModel>();

    //public static int  id = 0; 
   [HttpGet]
   [Route("CarteleraController/Get")]
   public async Task<BaseResponse> Get()
    {
        string query = carteleraModel.select(nombre);
        try
        {
            var rsp = await repository.GetListBy<dynamic>(query);
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Lista de entidades", data: rsp);
        }
        catch (Exception ex)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
   /*public BaseResponse Get()
    {
        return new DataResponse<List<CarteleraModel>>(true,(int)HttpStatusCode.OK,"Lista de Pelicula",DataLista);
    }*/

    [HttpPost]
    [Route("CarteleraController/Post")]
    
    public async Task<BaseResponse> Post([FromBody]CarteleraModel dataInput) 
    {                                                         
        //dataInput.id = Guid.NewGuid().ToString();             
        //DataList.Add(dataInput);                            
        
        string query = dataInput.insert();
        try
        {
            var rsp = await repository.InsertByQuery(query);

            return new DataResponse<dynamic>(true, (int)HttpStatusCode.Created, "Entidad creada correctamente", data: rsp);
        }
        catch(Exception ex)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, ex.Message);
        } 
    }

    /*public BaseResponse Post([FromBody]CarteleraModel dataInput)
    {
        id++;
        dataInput.id = id;
        DataLista.Add(dataInput);
        return new BaseResponse (true,(int)HttpStatusCode.Created, "Hola :D"); 
    }*/



    [HttpDelete]
    [Route("CarteleraController/Delete")]

    public async Task<BaseResponse> Delete([FromQuery]int id)
    {
        string query = carteleraModel.DeleteByQuery(nombre,id);
        try
        {
            var rsp = await repository.DeleteAsync(query);
            
            if(rsp == 0)
            {
                return new DataResponse<dynamic>(false, (int)HttpStatusCode.NotFound, "No se encontro el objeto", data: rsp);
            }
            else if(rsp == 1)
            {
                return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Objeto elminiado", data: rsp);
            }
            else
            {
                return new DataResponse<dynamic>(false, (int)HttpStatusCode.InternalServerError, "Se eliminaron multiples entidades.", data: rsp);
            }


        }
        catch(Exception ex)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    /*public BaseResponse Delete([FromQuery]int id)
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
    }*/

    [HttpPatch]
    [Route("CarteleraController/Patch")]

    public async Task<BaseResponse> Patch([FromBody]CarteleraModel dataInput)
    {
        string query = dataInput.update(nombre, dataInput.id);
        
            var rsp = await repository.DeleteAsync(query);
            
            if(rsp == 0)
            {
                return new DataResponse<dynamic>(false, (int)HttpStatusCode.NotFound, "No se encontro el objeto", data: rsp);
            }
            else if(rsp == 1)
            {
                return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Objeto modificado", data: rsp);
            }
            else
            {
                return new DataResponse<dynamic>(false, (int)HttpStatusCode.InternalServerError, "Se eliminaron multiples entidades.", data: rsp);
            } 
    }
    /*public BaseResponse Patch([FromBody]CarteleraModel dataInput)
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

    }*/


    [HttpPut]
    [Route("CarteleraController/Put")]

    public BaseResponse Put([FromBody]CarteleraModel dataInput)
    {
        if(dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "El parametro id es requerido");
        }

        CarteleraModel? peli = DataLista.FirstOrDefault(x => x.id == dataInput.id);

        if(peli == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El objeto no fue encontrado");
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
    /*public BaseResponse Put([FromBody]CarteleraModel dataInput)
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
    }*/
}
