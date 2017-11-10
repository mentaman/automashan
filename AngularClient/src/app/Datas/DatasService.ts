import { Injectable, EventEmitter } from '@angular/core';
import { DataModel } from "./DataModel";
import { Observable } from 'rxjs/Rx';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable()
export class DatasService {
    constructor(
        private http: HttpClient) {
            this.getDatas().subscribe(
                datas => {this.datas = datas; this.datasChange.emit(datas);}
              );
        }

    public datas: Map<number, DataModel>;
    datasChange: EventEmitter<Map<number, DataModel>> = new EventEmitter();


    getDatas(): Observable<Map<number, DataModel>> {
        return this.http.get<Map<number, DataModel>>("http://localhost:54153/api/GetAll").pipe(
            catchError(this.handleError<Map<number, DataModel>>('get datas', new Map<number, DataModel>()))
        );
    }
    private handleError<T> (operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

          // TODO: send the error to remote logging infrastructure
          console.error(error); // log to console instead


          // Let the app keep running by returning an empty result.
          return of(result as T);
        };
      }
}
