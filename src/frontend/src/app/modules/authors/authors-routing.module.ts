import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthorHomeComponent} from "./pages/author-home/author-home.component";
import {AuthorDetailComponent} from "./pages/author-detail/author-detail.component";
import {AuthorEditComponent} from "./pages/author-edit/author-edit.component";

const routes: Routes = [
  { path: 'authors', component: AuthorHomeComponent },
  { path: 'authors/:guid', component: AuthorDetailComponent},
  { path: 'authors/edit/:guid', component: AuthorEditComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AuthorsRoutingModule { }
