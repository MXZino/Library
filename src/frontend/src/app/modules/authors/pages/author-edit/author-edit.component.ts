import {Component, OnInit} from '@angular/core';
import {EditAuthor} from "../../interfaces/edit-author";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthorsHttpService} from "../../services/http/authors-http.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css']
})
export class AuthorEditComponent implements OnInit {
  authorForm!: FormGroup;
  authorData!: EditAuthor;
  authorId!: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private http: AuthorsHttpService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.authorForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      description: ['']
    });

    this.authorId = this.route.snapshot.paramMap.get('guid')!;
    this.http.getAuthor(this.authorId).subscribe({
      next: (data) => {
        let formattedDateOfBirth = new Date(data.dateOfBirth).toISOString().slice(0, 16);

        const {firstName, lastName, description} = data;
        this.authorData = {id: this.authorId, firstName, lastName, dateOfBirth: formattedDateOfBirth, description};
        this.authorForm.patchValue(this.authorData);
      }
    });
  }

  onSubmit() {
    if (!this.authorForm.valid) {
      return;
    }

    this.authorData = this.authorForm.value;
    this.authorData.id = this.authorId;

    this.http.editAuthor(this.authorData).subscribe({
      next: () => {
        this.router.navigate(["authors", this.authorId]);
        alert("Poprawnie edytowano autora");
      },
      error: (err) => {
        console.error('Error:', err);
      }
    });
  }
}
