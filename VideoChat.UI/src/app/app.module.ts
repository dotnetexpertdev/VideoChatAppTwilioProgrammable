import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CameraComponent } from './camera/camera.component';
// import { RoomsComponent } from './rooms/rooms.component';
import { HomeComponent } from './home/home.component';
import { ActivityIndicatorComponent } from './activity-indicator/activity-indicator.component';
import { ParticipantsComponent } from './participants/participants.component';
import { SettingsComponent } from './settings/settings.component';
import { RoomsComponent } from './rooms/rooms.component';

@NgModule({
  declarations: [
    
    
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    SettingsComponent,
    ParticipantsComponent,
    ActivityIndicatorComponent,
    HomeComponent,
    CameraComponent,
    RoomsComponent
  ]
})
export class AppModule { }
