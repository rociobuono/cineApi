using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ATDapi.Repositories;

namespace ATDapi.Controllers;

[ApiController]
public class CombosController : ControllerBase
{
    private Repository repository = new Repository();


    private CombosModel combosModel = new CombosModel();

    string nombre = "Combos";

    public static List<CombosModel> DataLista = new List<CombosModel>();

    public static int id = 0; 
    [HttpGet]
    [Route("CombosController/Get")]

    public async Task<BaseResponse> Get()
    {

        string query = combosModel.select(nombre);

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
    /*public BaseResponse Get(){
        
        return new DataResponse<List<CombosModel>>(true,(int)HttpStatusCode.OK,"Lista de combos",DataLista);
    }*/

    [HttpPost]
    [Route("CombosController/Post")]
    public async Task<BaseResponse> Post([FromBody]CombosModel dataInput) 
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
    /*public BaseResponse Post([FromBody]CombosModel dataInput){
        
        id++;
        dataInput.id = id;
        DataLista.Add(dataInput);
        return new BaseResponse (true,(int)HttpStatusCode.Created, "Combo creado"); 
    }*/

    [HttpDelete]
    [Route("CombosController/Delete")]
    public async Task<BaseResponse> Delete([FromQuery]int id)
    {

        string query = combosModel.DeleteByQuery(nombre,id);

        try
        {
            var rsp = await repository.DeleteAsync(query);
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Objeto elminiado", data: rsp);

        }
        catch(Exception ex)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    /*public BaseResponse Delete([FromQuery]int id){
        CombosModel? combo = DataLista.FirstOrDefault(x => x.id == id);

        if (combo == null)
        {
            return new BaseResponse(false,(int)HttpStatusCode.NotFound,"No se encontro el combo");
        }
        else{
            DataLista.Remove(combo);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Combo eliminada correctamente");
        }
    }*/

    [HttpPatch]
    [Route("CombosController/Patch")]

    public async Task<BaseResponse> Patch([FromBody]CombosModel dataInput)
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
    /*public BaseResponse Patch([FromBody] CombosModel dataInput){

        if (dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "No se encontro el id");
        }

        CombosModel? combos = DataLista.FirstOrDefault(x => x.id == dataInput.id);
        if (combos == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "No se encontro el combo");
        }
        else
        {
            DataLista.Remove(combos);
            DataLista.Add(dataInput);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Combo actualizada correctamente");
        }
    }*/

    [HttpPut]
    [Route("CombosController/Put")]
public BaseResponse Put([FromBody]CombosModel dataInput)
    {
        if(dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "El parametro id es requerido");
        }

        CombosModel? combo = DataLista.FirstOrDefault(x => x.id == dataInput.id);

        if(combo == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El objeto no fue encontrado");
        }
        else
        {
            DataLista.Remove(combo);
            if(dataInput.titulo != null)
            {
                combo.titulo = dataInput.titulo;
            }
            if(dataInput.imagen != null)
            {
                combo.imagen = dataInput.imagen;
            }
            if(dataInput.descripcion != null)
            {
                combo.descripcion = dataInput.descripcion;
            }
            DataLista.Add(combo);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Combo modificado");
        }
    }
   /* public BaseResponse Put([FromBody] CombosModel dataInput){
        if(dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "No se encontro el id");
        }
        CombosModel? combo = DataLista.FirstOrDefault(x => x.id == dataInput.id);
        if(combo == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El combo no fue encontrado");
        }
        else
        {
            DataLista.Remove(combo);
            if(dataInput.titulo != null)
            {
                combo.titulo = dataInput.titulo;
            }
            if(dataInput.imagen != null)
            {
                combo.imagen = dataInput.imagen;
            }
            if(dataInput.descripcion != null)
            {
                combo.descripcion = dataInput.descripcion;
            }
            DataLista.Add(combo);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Combo modificado");
        }
    }*/



}