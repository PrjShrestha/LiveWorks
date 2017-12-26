// ======================================
// Author: liveworks  
// Email:  info@liveworks.com
// Copyright (c) 2017 www.liveworks.com
// 
// ==> Gun4Hire: contact@liveworks.com
// ======================================

import { PermissionValues } from './permission.model';


export interface LoginResponse {
    access_token: string;
    id_token: string;
    refresh_token: string;
    expires_in: number;
}


export interface IdToken {
    sub: string;
    name: string;
    fullname: string;
    jobtitle: string;
    email: string;
    phone: string;
    role: string | string[];
    permission: PermissionValues | PermissionValues[];
    configuration: string;
}