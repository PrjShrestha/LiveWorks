import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { environment } from '../../environments/environment';

import { FilteredResponse } from '../EntityDto/filtered-response';

@Injectable()
export abstract class HttpCrudService<T> {

    private readonly _apiUrl: string;

    constructor(protected http: HttpClient) {
        this._apiUrl = `${environment.baseApiUrl}/${this.getBaseEndPoint()}`;
    }

    get ApiUrl(): string {
        console.log(this._apiUrl);
        return this._apiUrl;
    }

    protected abstract getBaseEndPoint(): string;

    protected sendRequest(request) {
        return request
            .map(this.handleSuccess)
            .catch(this.handleError);
    }

    protected getCommonOptions() {
        const options = Object.create(HttpClient.prototype.options.prototype);
        options.observe = 'response';

        return options;
    }

    getById(id: number): Observable<FilteredResponse<T>> {
        const getUrl = `${this.ApiUrl}/${id}`;
        return this.sendRequest(this.http.get(getUrl, this.getCommonOptions()));
    }

    getAll(): Observable<FilteredResponse<T>> {
        return this.sendRequest(this.http.get(this.ApiUrl, this.getCommonOptions()));
    }

    add(body: T): Observable<FilteredResponse<T>> {
        return this.sendRequest(this.http.post(this.ApiUrl, body, this.getCommonOptions()));
    }

    update(body: T): Observable<FilteredResponse<T>> {
        return this.sendRequest(this.http.put(this.ApiUrl, body, this.getCommonOptions()));
    }

    delete(id: number): Observable<FilteredResponse<string>> {
        const deleteUrl = `${this.ApiUrl}/${id}`;
        return this.http.delete(deleteUrl, { responseType: 'text', observe: 'response' })
            .map((response: HttpResponse<String>) =>
                new FilteredResponse<string>(
                    response.body.toString(),
                    response.status))
            .catch(this.handleError);
    }

    protected handleSuccess(response: HttpResponse<T>) {
        return new FilteredResponse(response.body, response.status);
    }

    protected handleError(error: HttpErrorResponse) {
        if (error.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            return Observable.throw(new Error(error.message));
        } else {
            let err = error.error;
            //Error can be in String (eg: Invalid Entity) or An Object which needs to be converted to js object.
            if (err instanceof Object) {
                err = JSON.stringify(err);
            }
            // The backend query was unsuccessful. We pass only the error message and status code to component.
            // The response body may contain clues as what was wrong. i.e. invalid entity, Id missing etc
            return Observable.throw(new Error(`Message: ${err}. Status Code: ${error.status}.`));
        }
    }
}