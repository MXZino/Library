import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {EditBook} from "../../interfaces/edit-book";
import {ActivatedRoute, Router} from "@angular/router";
import {BooksHttpService} from "../../services/books-http.service";

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  bookForm!: FormGroup;
  bookData!: EditBook;
  bookId!: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private http: BooksHttpService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.bookForm = this.formBuilder.group({
      title: ['', Validators.required],
      authorId: ['', Validators.required],
      ibnr: ['', Validators.required],
      year: ['', Validators.required]
    });

    this.bookId = this.route.snapshot.paramMap.get('guid')!;
    this.http.getBook(this.bookId).subscribe({
      next: (data) => {
        const {title, author, ibnr, year} = data;
        this.bookData = {id: this.bookId, title, ibnr, year, authorId: author.id};
        this.bookForm.patchValue(this.bookData);
      }
    });
  }

  onSubmit() {
    if (!this.bookForm.valid) {
      return;
    }

    this.bookData = this.bookForm.value;
    this.bookData.id = this.bookId;

    this.http.editBook(this.bookData).subscribe({
      next: () => {
        this.router.navigate(["books", this.bookId]);
        alert("Poprawnie edytowano książkę");
      },
      error: (err) => {
        console.error('Error:', err);
      }
    });
  }

}
