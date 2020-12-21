import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PersonListComponent } from './components/person/list/person-list.component';
import { PersonAddComponent } from './components/person/add/person-add.component';


const routes: Routes = [  
  { path: 'person', redirectTo: 'person', pathMatch: 'full' },
  { path: 'person', component: PersonListComponent },
  { path: 'person/add', component: PersonAddComponent },
  { path: 'person/add/:id', component: PersonAddComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
