import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { PersonPhone } from 'src/app/models/person-phone';
import { PhoneNumberType } from 'src/app/models/phone-number-type';
import { PhoneNumberTypeResponse } from 'src/app/models/phone-number-type-response';
import { PersonService } from 'src/app/service/person.service';

@Component({
  selector: 'app-person-add',
  templateUrl: './person-add.component.html',
  styleUrls: ['./person-add.component.css']
})
export class PersonAddComponent implements OnInit {

  phoneTypes: PhoneNumberType[] = [];

  title = 'Persons';
  person: Person = {
    id: 0,
    name: '',
    phones: []
  };

  constructor(
    public personService: PersonService
  ) { }

  ngOnInit(): void { 
    this.personService.getPhoneNumberTypes().subscribe((data:PhoneNumberTypeResponse) => {
      console.log(data);
      this.phoneTypes = data.phoneNumberTypeObjects;      
    });

  }

  submitForm(): void {
    console.log(this.person);
  }

  addPhone(): void {
    this.person.phones.push({
      phoneNumber: '',
      phoneNumberTypeID: 1,
      personID: this.person.id,
      phoneNumberType: this.phoneTypes[0]
    });
  }

  removePhone(phone:PersonPhone): void{
    this.person.phones = this.person.phones.filter(p => p != phone);
  }
  
}