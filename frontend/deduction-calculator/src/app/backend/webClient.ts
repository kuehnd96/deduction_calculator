import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';
import { Inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee} from '../models/employee';

export class webClient {
    private http: HttpClient;
    private baseUrl: string;

    constructor(@Inject(HttpClient) http: HttpClient) {
        this.http = http;
        this.baseUrl = environment.baseUrl != undefined && environment.baseUrl !== null ? environment.baseUrl : "";
    }

    calculateDeduction(employee: Employee) : number {
      let url = this.baseUrl + "DeductionCalculator";
      url = url.replace(/[?&]$/, "");

      const content = JSON.stringify(employee);

      let options: any = {
        body: content,
        observe: "response",
        responseType: "blob",
        headers: new HttpHeaders({
            "Conent-Type": "application/json",
            "Accept": "application/json"
        })
      };

      //let deduction: number;

      this.http.post<number>(url, options).subscribe({
          next: data => {
              console.log(data);
          },
          error: error => {
              console.error('There was an error: ' + error);
          }
      })

      return 12;
    }
}