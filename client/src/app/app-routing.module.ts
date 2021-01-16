import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AdminGuard } from './_guards/admin.guard';
import { LandingComponent } from './landing/landing.component';
import { TxqohComponent } from './inventory/txqoh/txqoh.component';
import { TxqohCreateComponent } from './inventory/txqoh-create/txqoh-create.component';
import { TxqohModalComponent } from './inventory/txqoh-modal/txqoh-modal.component';
import { PurchaseordersComponent } from './supplychain/purchaseorders/purchaseorders.component';
import { PoplanCreateComponent } from './supplychain/poplan-create/poplan-create.component';
import { PoplanModalComponent } from './supplychain/poplan-modal/poplan-modal.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'landing', component: LandingComponent},
      {path: 'txqoh', component: TxqohComponent},
      {path: 'txqoh-modal', component: TxqohModalComponent},      
      {path: 'txqoh-create', component: TxqohCreateComponent},
      {path: 'members/:username', component: MemberDetailComponent, resolve: {member: MemberDetailedResolver}},
      {path: 'member/edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      {path: 'lists', component: ListsComponent},
      {path: 'messages', component: MessagesComponent},
      {path: 'purchaseorders', component: PurchaseordersComponent},
      {path: 'poplan-create', component: PoplanCreateComponent},
      {path: 'poplan-modal', component: PoplanModalComponent},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},

    ]
  },
  {path: 'errors', component: TestErrorsComponent },
  {path: 'not-found', component: NotFoundComponent },
  {path: 'server-error', component: ServerErrorComponent },
  {path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
