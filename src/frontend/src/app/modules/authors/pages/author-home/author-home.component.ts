import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {AuthorsHttpService} from "../../services/http/authors-http.service";
import {PageResult} from "../../../shared/interfaces/page-result";
import {AuthorWithBooks} from "../../interfaces/author-with-books";
import {LoaderService} from "../../../loader/services/loader.service";

@Component({
  selector: 'app-author-home',
  templateUrl: './author-home.component.html',
  styleUrls: ['./author-home.component.css']
})
export class AuthorHomeComponent implements OnInit{

  name: string | null = null;
  page: number = 1;
  recordsPerPage: number = 20;
  authorsWithBooksResult: PageResult<AuthorWithBooks> | null = null;

  constructor(private route: ActivatedRoute, private http: AuthorsHttpService, private router: Router, private loaderService: LoaderService) {
  }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.name = params.get('name');

      this.page = Number(params.get('page')) || 1;

      if(this.page < 1)
        this.page = 1;

      this.recordsPerPage = Number(params.get('recordsPerPage')) || 20;

      if(this.recordsPerPage < 10)
        this.recordsPerPage = 10;

      if(this.recordsPerPage > 100)
        this.recordsPerPage = 100;

      this.getAllAuthors();
    });
  }

  private getAllAuthors() {
    this.updateUrl();
    this.http.getAllAuthors(this.page, this.recordsPerPage, this.name).subscribe({
      next: (data) => {
        this.authorsWithBooksResult = data;
        this.loaderService.isLoading.next(false);
      },
      error: (err) => {
        console.error('Error:', err);
        this.loaderService.isLoading.next(false);
        this.loaderService.error.next('Nie udało się pobrać danych.');
      }
    });
  }

  private updateUrl() : void{
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { page: this.page, recordsPerPage: this.recordsPerPage, name: this.name },
      queryParamsHandling: 'merge'
    });
  }

  public onPageSelected(page: number){
    this.page = page;
    this.getAllAuthors();
  }

  public onRecordsPerPageChanged(recordsPerPage: number) {
    this.page = 1;
    this.recordsPerPage = recordsPerPage;
    this.getAllAuthors()
  }

  applyFilter(filterName: string) {
    this.name = filterName;
    this.page = 1;
    this.getAllAuthors();
  }
}
