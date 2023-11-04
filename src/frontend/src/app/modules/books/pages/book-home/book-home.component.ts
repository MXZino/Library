import {Component, OnInit} from '@angular/core';
import {PageResult} from "../../../shared/interfaces/page-result";
import {BookWithAuthor} from "../../interfaces/book-with-author";
import {ActivatedRoute, Router} from "@angular/router";
import {LoaderService} from "../../../shared/services/loader.service";
import {BooksHttpService} from "../../services/books-http.service";
import {BooksFilter} from "../../models/books-filter";

@Component({
  selector: 'app-book-home',
  templateUrl: './book-home.component.html',
  styleUrls: ['./book-home.component.css']
})
export class BookHomeComponent implements OnInit {

  booksFilter: BooksFilter = new BooksFilter();

  page: number = 1;
  recordsPerPage: number = 20;

  booksWithAuthors: PageResult<BookWithAuthor> | null = null;

  addButtonText = "Dodaj książkę";
  addButtonPath = "books/add";
  constructor(private route: ActivatedRoute, private http: BooksHttpService, private router: Router, private loaderService: LoaderService) {
  }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.booksFilter.title = params.get('title');

      this.booksFilter.authorName = params.get('authorName');

      this.booksFilter.yearEqualGreaterThan = Number(params.get('yearEqualGreaterThan')) || -10000;

      this.page = Number(params.get('page')) || 1;

      if (this.page < 1)
        this.page = 1;

      this.recordsPerPage = Number(params.get('recordsPerPage')) || 20;

      if (this.recordsPerPage < 10)
        this.recordsPerPage = 10;

      if (this.recordsPerPage > 100)
        this.recordsPerPage = 100;

      this.getAllBooks();
    });
  }

  private getAllBooks() {
    this.updateUrl();
    this.http.getAllBooks(this.page, this.recordsPerPage, this.booksFilter).subscribe({
      next: (data) => {
        this.booksWithAuthors = data;
        this.loaderService.isLoading.next(false);
      },
      error: (err) => {
        console.error('Error:', err);
        this.loaderService.isLoading.next(false);
        this.loaderService.error.next('Nie udało się pobrać danych.');
      }
    });
  }

  private updateUrl(): void {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: {
        page: this.page,
        recordsPerPage: this.recordsPerPage,
        title: this.booksFilter.title,
        authorName: this.booksFilter.authorName,
        yearEqualGreaterThan: this.booksFilter.yearEqualGreaterThan
      },
      queryParamsHandling: 'merge'
    });
  }

  public onPageSelected(page: number) {
    this.page = page;
    this.getAllBooks();
  }

  public onRecordsPerPageChanged(recordsPerPage: number) {
    this.page = 1;
    this.recordsPerPage = recordsPerPage;
    this.getAllBooks()
  }

  applyFilter(booksFilter: BooksFilter) {
    this.booksFilter = booksFilter;

    this.page = 1;
    this.getAllBooks();
  }
}
