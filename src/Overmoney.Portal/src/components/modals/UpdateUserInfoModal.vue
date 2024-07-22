<template>
    <dialog :open="show">
    <article>
        <header>
            <button aria-label="Close" rel="prev" @click="cancel"></button>
            Update User Info
        </header>
        <form @submit.prevent="updateUserInfo">
                    <label for="email">Email</label>
                    <input type="email" v-model="userInfo.email" id="email" required/>

                    <button type="submit">Update</button>
                </form>
    </article>
</dialog>
</template>

<script lang="ts">
import type { updateUserInfoRequest } from '@/data_access/models/requests/updateUserInfoRequest';

export default {
props: {
    show: Boolean,
    currentEmail: String
},

data() {
    let userInfo = {} as updateUserInfoRequest;
    userInfo.email = this.currentEmail as string
    return {
        userInfo,
    }
},
methods: {
    async updateUserInfo() {
        this.$emit('updated', this.userInfo);
        this.clearForm();
    },
    cancel() {
        this.$emit('cancel');
        this.clearForm();
    },
    clearForm(){
        this.userInfo = { } as updateUserInfoRequest;
    }
}
}
</script>