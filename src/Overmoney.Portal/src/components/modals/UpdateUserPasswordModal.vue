<template>
    <dialog :open="show">
    <article>
        <header>
            <button aria-label="Close" rel="prev" @click="cancel"></button>
            Update Password
        </header>
        <form @submit.prevent="updatePassword">
                    <label for="old_password">Old password</label>
                    <input type="password" v-model="password.oldPassowrd" id="old_password" required/>

                    <label for="new_password">New password</label>
                    <input type="password" v-model="password.newPassword" id="new_password" required/>
                    
                    <label for="repeat_password">Repeat new password</label>
                    <input type="password" v-model="password.repeatPassword" id="repeat_password" required/>

                    <button type="submit">Update</button>
                </form>
    </article>
</dialog>
</template>

<script lang="ts">
import type { updatePasswordRequest } from '@/data_access/models/requests/updatePasswordRequest';


export default {
props: {
    show: Boolean,
},

data() {
    let password = {} as updatePasswordRequest;

    return {
        password,
    }
},
methods: {
    async updatePassword() {
        this.$emit('updated', this.password);
        this.clearForm();
    },
    cancel() {
        this.$emit('cancel');
        this.clearForm();
    },
    clearForm(){
        this.password = { } as updatePasswordRequest;
    }
}
}
</script>