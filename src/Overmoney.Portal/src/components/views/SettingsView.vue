<template>
    <h5>Settings</h5>
    <div style="margin-top: 5%;">
        <article>
            User Information
            <div>
                <button @click="showUserInfoModal = true">Change user information</button>
            </div>
        </article>

        <article>
            Password
            <div>
                <button @click="showPasswordModal = true">Change password</button>
            </div>
        </article>
        <UpdateUserPasswordModal :show="showPasswordModal"  @updated="onPasswordUpdate" @cancel="showPasswordModal = false" />
        <UpdateUserInfoModal :show="showUserInfoModal" :currentEmail="currentEmail" @updated="onUserInfoUpdate" @cancel="showUserInfoModal = false" />
    </div>


</template>

<script lang="ts">
import { Client } from '@/data_access/client';
import { userSessionStore } from '@/data_access/sessionStore';
import type { updatePasswordRequest } from '@/data_access/models/requests/updatePasswordRequest';
import UpdateUserPasswordModal from '@/components/modals/UpdateUserPasswordModal.vue';
import type { updateUserInfoRequest } from '@/data_access/models/requests/updateUserInfoRequest';
import UpdateUserInfoModal from '@/components/modals/UpdateUserInfoModal.vue';

export default {
    data() {
        const client = new Client();
        const session = userSessionStore();
        return {
            client,
            showUserInfoModal: false,
            showPasswordModal: false,
            disableRemove: false,
            currentEmail: session.email,
            session
        }
    },
    methods:{
        onPasswordUpdate(password: updatePasswordRequest){
            if(password.newPassword !== password.repeatPassword){
                alert("Passwords are different!");
                return;
            }
            this.showPasswordModal = false;
            console.log(password);
        },
        onUserInfoUpdate(userInfo: updateUserInfoRequest){
            this.showUserInfoModal = false;
            console.log(userInfo);
        }
    },
    components: {
        UpdateUserPasswordModal,
        UpdateUserInfoModal
    }
}
</script>

<style scoped lang="css">
form {
    display: flex;
    flex-direction: column;
    justify-content: center;
    margin-left: auto;
    margin-right: auto;
    padding: var(--pico-block-spacing-vertical) var(--pico-block-spacing-horizontal);
}
button{
    width: 250px;
    display: flex;
    margin: auto;
    justify-content: center;
}
</style>