using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ATDapi.Controllers;

[ApiController]
public class DemoController : ControllerBase
{
    public static List<SimpleModel> DataList = new List<SimpleModel>();

    [HttpGet]
    [Route("Get")]
    public BaseResponse Get()
    {
        return new DataResponse<List<SimpleModel>>(true, (int)HttpStatusCode.OK, "Lista de entidades", DataList);
    }

    [HttpPost]
    [Route("Post")]
    public BaseResponse Post([FromBody]SimpleModel dataInput)
    {
        dataInput.id = Guid.NewGuid();
        DataList.Add(dataInput);
        return new BaseResponse(true, (int)HttpStatusCode.Created, "Entidad creada correctamente");
    }

    [HttpPut]
    [Route("Put")]
    public BaseResponse Put([FromBody]SimpleModel dataInput)
    {
        if(dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "El parametro id es requerido");
        }

        SimpleModel? tmp = DataList.FirstOrDefault(x => x.id == dataInput.id);

        if(tmp == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El objeto no fue encontrado");
        }
        else
        {
            DataList.Remove(tmp);
            if(dataInput.message != null)
            {
                tmp.message = dataInput.message;
            }

            if(dataInput.number != null)
            {
                tmp.number = dataInput.number;
            }

            DataList.Add(tmp);

            return new BaseResponse(true, (int)HttpStatusCode.OK, "Objeto parcialmente actualizado");
        }
    }

    [HttpPatch]
    [Route("Patch")]
    public BaseResponse Patch([FromBody]SimpleModel dataInput)
    {
        if(dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "El parametro id es requerido");
        }

        SimpleModel? tmp = DataList.FirstOrDefault(x => x.id == dataInput.id);

        if(tmp == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El objeto no fue encontrado");
        }
        else
        {
            DataList.Remove(tmp);
            DataList.Add(dataInput);

            return new BaseResponse(true, (int)HttpStatusCode.OK, "Objeto actualizado");
        }
    }

    [HttpDelete]
    [Route("Delete")]
    public BaseResponse Delete([FromQuery]Guid id)
    {
        SimpleModel? tmp = DataList.FirstOrDefault(x => x.id == id);

        if(tmp == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El objeto no fue encontrado");
        }
        else
        {
            DataList.Remove(tmp);

            return new BaseResponse(true, (int)HttpStatusCode.OK, "Objeto parcialmente eliminado");
        }
    }
}