import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BugtrackerIndexComponent } from './component/bugtracker/bugtracker-index/bugtracker-index.component';
import { ProjectIndexComponent } from './component/project/project-index/project-index.component';
import { ContactMeComponent } from './component/static/contact-me/contact-me.component';
import { HomeComponent } from './component/static/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'contactme', component: ContactMeComponent },
  { path: 'projects', component: ProjectIndexComponent },
  { path: 'bugs', component: BugtrackerIndexComponent },
  { path:'home', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
