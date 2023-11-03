import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthorHomeComponent} from "./pages/author-home/author-home.component";

const routes: Routes = [
  { path: 'authors', component: AuthorHomeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AuthorsRoutingModule { }
