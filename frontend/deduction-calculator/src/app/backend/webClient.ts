import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee} from '../models/employee';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class WebClient {
    private http: HttpClient;
    private baseUrl: string;

    constructor(@Inject(HttpClient) http: HttpClient) {
        this.http = http;
        this.baseUrl = environment.baseUrl != undefined && environment.baseUrl !== null ? environment.baseUrl : "";
    }

    calculateDeduction(employee: Employee) : Observable<number> {
      let url = this.baseUrl + "DeductionCalculator";
      url = url.replace(/[?&]$/, "");

      const content = JSON.stringify(employee);
      
      // Why does this mess up the model binding on the back end?
      /*
      let options: any = {
        body: content,
        headers: new HttpHeaders({
            "Content-Type": "application/json",
            "Accept": "text/plain"
        })
      };
      */

      return this.http.post<number>(url, employee).pipe(catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse) {
        if (error.status === 0) {
          // A client-side or network error occurred. Handle it accordingly.
          console.error('An error occurred:', error.error);
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong.
          console.error(
            `Backend returned code ${error.status}, body was: `, error.error);
        }
        // Return an observable with a user-facing error message.
        return throwError(
          'Something bad happened; please try again later.');
      }
}