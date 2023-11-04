import {Component, Input} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-button',
  templateUrl: './add-button.component.html',
  styleUrls: ['./add-button.component.css']
})
export class AddButtonComponent {
  @Input() path!: string;
  @Input() text!: string;

  constructor(private router: Router) {
  }

  goToAddPage() {
    console.log(this.path);
    this.router.navigate([this.path]);
  }
}
