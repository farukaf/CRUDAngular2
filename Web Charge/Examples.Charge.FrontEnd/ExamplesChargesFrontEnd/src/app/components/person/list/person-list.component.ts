import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/person';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PersonService } from 'src/app/service/person.service';
import { PersonResponse } from 'src/app/models/person-response';


@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  persons: Person[] = [];

  title = 'Persons';

  constructor(public personService: PersonService) { }

  ngOnInit(): void {
    this.personService.get().subscribe((data: PersonResponse) => {
      console.log(data);
      this.persons = data.personObjects;
    })
  }

  deletePerson(person: Person) {
    this.personService.delete(person.id).subscribe(res => {
      this.persons = this.persons.filter(p => p != person);      
    });
  }
}