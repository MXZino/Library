import {Component, Input} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-edit-button',
  templateUrl: './edit-button.component.html',
  styleUrls: ['./edit-button.component.css']
})
export class EditButtonComponent {
  @Input() path!: string

  constructor(private router: Router) {
  }

  goToEditPage() {
    console.log(this.path);
    this.router.navigate([this.path]);
  }
}
