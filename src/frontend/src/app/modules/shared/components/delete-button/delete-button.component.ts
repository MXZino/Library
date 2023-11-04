import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-delete-button',
  templateUrl: './delete-button.component.html',
  styleUrls: ['./delete-button.component.css']
})
export class DeleteButtonComponent {
  @Input() text!: string;
  @Output() onConfirm = new EventEmitter<void>();

  confirmDeletion() {
    if(confirm(this.text)) {
      this.onConfirm.emit();
    }
  }

}
