import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
    private router: Router,
    public personService: PersonService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.personService.getPhoneNumberTypes().subscribe((data: PhoneNumberTypeResponse) => {
      console.log(data);
      this.phoneTypes = data.phoneNumberTypeObjects;
    });

    let id = parseInt(this.route.snapshot.paramMap.get('id') || '0');
    if(id){
      this.personService.getById(id).subscribe(res => {
        if (res.personObjects.length) {
          this.person = res.personObjects[0];
        }
      });
    }

  }

  submitForm(): void {
    console.log(this.person);
    if (this.person.id == 0)
      this.personService.post(this.person).subscribe(res => {
        this.router.navigateByUrl('person');
      });
    else
      this.personService.put(this.person).subscribe(res => {
        this.router.navigateByUrl('person');
      });
  }

  addPhone(): void {
    this.person.phones.push({
      phoneNumber: '',
      phoneNumberTypeID: 1,
      personID: this.person.id,
      phoneNumberType: this.phoneTypes[0]
    });
  }

  removePhone(phone: PersonPhone): void {
    this.person.phones = this.person.phones.filter(p => p != phone);
  }

}