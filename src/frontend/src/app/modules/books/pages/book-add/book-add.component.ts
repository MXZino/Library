import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {EditBook} from "../../interfaces/edit-book";
import {Router} from "@angular/router";
import {BooksHttpService} from "../../services/books-http.service";

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.css']
})
export class BookAddComponent implements OnInit{
  bookForm!: FormGroup;
  bookData!: EditBook;

  constructor(
    private formBuilder: FormBuilder,
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
  }

  onSubmit() {
    if (!this.bookForm.valid) {
      return;
    }

    this.bookData = this.bookForm.value;

    this.http.addBook(this.bookData).subscribe({
      next: () => {
        this.router.navigate(["books"]);
        alert("Poprawnie dodano książkę");
      },
      error: (err) => {
        console.error('Error:', err);
      }
    });
  }

}
