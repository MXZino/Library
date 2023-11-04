import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {PaginatorComponent} from './components/paginator/paginator.component';
import {LoaderComponent} from "./components/loader/loader.component";
import {DeleteButtonComponent} from './components/delete-button/delete-button.component';
import {EditButtonComponent} from './components/edit-button/edit-button.component';
import {AddButtonComponent} from "./components/add-button/add-button.component";


@NgModule({
  declarations: [
    PaginatorComponent,
    LoaderComponent,
    DeleteButtonComponent,
    EditButtonComponent,
    AddButtonComponent
  ],
  exports: [
    PaginatorComponent,
    LoaderComponent,
    EditButtonComponent,
    DeleteButtonComponent,
    AddButtonComponent,
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule {
}
