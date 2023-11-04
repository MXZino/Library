import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AddAuthor} from "../../interfaces/add-author";
import {AuthorsHttpService} from "../../services/http/authors-http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-author-add',
  templateUrl: './author-add.component.html',
  styleUrls: ['./author-add.component.css']
})
export class AuthorAddComponent implements OnInit {
  authorForm!: FormGroup;
  authorData!: AddAuthor;

  constructor(private formBuilder: FormBuilder, private http: AuthorsHttpService, private router: Router) {
  }

  ngOnInit(): void {
    this.authorForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      description: ['']
    });
  }

  onSubmit() {

    if (!this.authorForm.valid) {
      return;
    }

    this.authorData = this.authorForm.value;

    this.http.addAuthor(this.authorData).subscribe({
      next: () => {
        this.router.navigate(["authors"]);
        alert("Poprawnie dodano autora");
      },
      error: (err) => {
        console.error('Error:', err);
      }
    });
  }
}

