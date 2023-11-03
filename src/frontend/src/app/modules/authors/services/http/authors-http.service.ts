import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import {AuthorWithBooks} from "../../interfaces/author-with-books";
import {environment} from "../../../../../environments/environment";
import {PageResult} from "../../../shared/interfaces/page-result";

@Injectable({
  providedIn: 'root'
})
export class AuthorsHttpService {

  constructor(private http: HttpClient) { }

  getAllAuthors(page: number, recordsPerPage: number, name: string | null): Observable<PageResult<AuthorWithBooks>> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('recordsPerPage', recordsPerPage.toString());

    if (name !== null) {
      params = params.set('name', name);
    }

    return this.http.get<PageResult<AuthorWithBooks>>(`${environment.apiUrl}/api/authors/all`, { params })
      .pipe(
        catchError(error => {
          console.log('Error while fetching authors:', error);
          return throwError(error);
        })
      );
  }
}
