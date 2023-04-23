namespace Catalog.Entities;

public class OryonContentResponse <T>
{

    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public int TotalRecords {get; set; } = 0;
    public List<string> Error {get; set; } = new List<string>();

    public OryonContentResponse<T> SetFail(Exception ex){
        return new OryonContentResponse<T>(){
                Success = false,
                TotalRecords = 0,
                Error = new List<string>(){ex.ToString()}
        };
    }

    public OryonContentResponse<T> SetSuccess(T data, int records){
        return new OryonContentResponse<T>(){
                Data = data,
                Success = true,
                TotalRecords = records
        };
    }

    public OryonContentResponse<T> SetSuccess(){
        return new OryonContentResponse<T>(){
                Success = true
        };
    }
}