import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Person } from 'src/app/models/person';
import { PersonResponse } from 'src/app/models/person-response';
import { PhoneNumberTypeResponse } from '../models/phone-number-type-response';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private apiServer = "http://localhost:49156/api/";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  get(): Observable<PersonResponse> {
    return this.httpClient.get<PersonResponse>(this.apiServer + 'person')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  post(person:Person): Observable<PersonResponse> {
    return this.httpClient.post<PersonResponse>(this.apiServer + 'person', JSON.stringify(person), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getPhoneNumberTypes(): Observable<PhoneNumberTypeResponse>{
    return this.httpClient.get<PhoneNumberTypeResponse>(this.apiServer + 'person/phoneNumberTypes')
    .pipe(
      catchError(this.errorHandler)
    );
  }

  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
