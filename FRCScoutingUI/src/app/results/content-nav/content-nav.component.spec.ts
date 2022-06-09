import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentNavComponent } from './content-nav.component';

describe('ContentNavComponent', () => {
  let component: ContentNavComponent;
  let fixture: ComponentFixture<ContentNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContentNavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
