import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from './components/paginator/paginator.component';
import {LoaderComponent} from "./components/loader/loader.component";
import { DeleteButtonComponent } from './components/delete-button/delete-button.component';
import { EditButtonComponent } from './components/edit-button/edit-button.component';

@NgModule({
  declarations: [
    PaginatorComponent,
    LoaderComponent,
    DeleteButtonComponent,
    EditButtonComponent
  ],
  exports: [
    PaginatorComponent,
    LoaderComponent,
    EditButtonComponent,
    DeleteButtonComponent,
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
