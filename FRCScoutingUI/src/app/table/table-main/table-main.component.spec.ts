/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TableMainComponent } from './table-main.component';

describe('TableMainComponent', () => {
  let component: TableMainComponent;
  let fixture: ComponentFixture<TableMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
