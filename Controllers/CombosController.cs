using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ATDapi.Controllers;

[ApiController]
public class CombosController : ControllerBase
{
    public static List<CombosModel> DataLista = new List<CombosModel>();

    public static int id = 0; 
    [HttpGet]
    [Route("CombosController/Get")]
    public BaseResponse Get(){
        
        return new DataResponse<List<CombosModel>>(true,(int)HttpStatusCode.OK,"Lista de combos",DataLista);
    }

    [HttpPost]
    [Route("CombosController/Post")]

    public BaseResponse Post([FromBody]CombosModel dataInput){
        
        id++;
        dataInput.id = id;
        DataLista.Add(dataInput);
        return new BaseResponse (true,(int)HttpStatusCode.Created, "Combo creado"); 
    }

    [HttpDelete]
    [Route("CombosController/Delete")]
    public BaseResponse Delete([FromQuery]int id){
        CombosModel? combo = DataLista.FirstOrDefault(x => x.id == id);

        if (combo == null)
        {
            return new BaseResponse(false,(int)HttpStatusCode.NotFound,"No se encontro el combo");
        }
        else{
            DataLista.Remove(combo);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Combo eliminada correctamente");
        }
    }

    [HttpPatch]
    [Route("CombosController/Patch")]

    public BaseResponse Patch([FromBody] CombosModel dataInput){

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
    }

    [HttpPut]
    [Route("CombosController/Put")]

    public BaseResponse Put([FromBody] CombosModel dataInput){
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
    }



}