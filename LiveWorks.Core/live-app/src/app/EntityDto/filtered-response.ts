export class FilteredResponse<T>{
    value: T[] | T;
    statusCode : number;
    constructor(value: T[] | T, statusCode: number){
        this.value = value;
        this.statusCode = statusCode;
    }
}