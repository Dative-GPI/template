<template>
  <v-container fill-height fluid class="pa-0 ma-0 d-flex">
    <v-row no-gutters class="fill-height">
      <v-col cols="10" sm="8" md="5" lg="4" xl="3" class="pa-8 d-flex flex-column">
        <template v-if="landingPage">
          <v-row no-gutters class="flex-grow-0 mb-4">
            <v-col cols="10">
              <d-blur-img
                v-if="landingPage.bannerImageId != null"
                :height="50"
                :width="330"
                fullfill
                :src="IMAGE_RAW_URL(landingPage.bannerImageId)"
                :imageBlurHash="landingPage.bannerImageBlurHash"
                :imageHeight="landingPage.bannerImageHeight"
                :imageWidth="landingPage.bannerImageWidth"
              />
            </v-col>
            <v-col cols="2">
              <language-selector />
            </v-col>
          </v-row>
          <v-row no-gutters class="flex-grow-0 mb-4">
            <span class="text-h3 black-1--text">{{ landingPage.title }}</span>
          </v-row>
          <v-row no-gutters class="flex-grow-0 mb-4">
            <span class="text-h5 grey-3--text">{{ landingPage.subTitle }}</span>
          </v-row>
          <router-view v-on="$listeners" />
          <v-row no-gutters class="flex-grow-0 mt-auto">
            <d-btn
              class="mr-6"
              icon
              v-for="(link, index) in landingPage.links"
              :key="index"
              :href="link.uri"
            >
              <d-icon>{{ link.icon }}</d-icon>
            </d-btn>
          </v-row>
        </template>
        <template v-else>
          <v-skeleton-loader type="article, list-item-three-line" />
        </template>
      </v-col>
      <v-col cols="2" sm="4" md="7" lg="8" xl="9">
        <d-blur-img
          v-resize="onResize"
          v-if="landingPage && landingPage.backgroundImageId != null"
          :contain="true"
          :height="height"
          :width="width"
          fullfill
          :src="IMAGE_RAW_URL(landingPage.backgroundImageId)"
          :imageBlurHash="landingPage.backgroundImageBlurHash"
          :imageHeight="landingPage.backgroundImageHeight"
          :imageWidth="landingPage.backgroundImageWidth"
        />
        <v-skeleton-loader type="image" class="landing-background" v-else />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Vue, InjectReactive, Inject } from "vue-property-decorator";
import VueRouter from "vue-router";

import { ILandingPageService } from "@/interfaces";
import { APPLICATION, PROVIDER, SERVICES as S, IMAGE_RAW_URL } from "@/config";
import { ApplicationDetails, LandingPage, LandingPageDetails } from "@/domain/models";

import LanguageSelector from "@/components/shared/LanguageSelector.vue";

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/account/create",
      component: () => import("@/components/landing/pages/SignUpPage.vue"),
    },
    {
      path: "/account/reset-password",
      component: () => import("@/components/landing/pages/ResetPage.vue"),
    },
    {
      path: "/account/lost",
      component: () => import("@/components/landing/pages/AskResetPage.vue"),
    },
    {
      path: "/account/validate",
      component: () => import("@/components/landing/pages/ValidatePage.vue"),
    },
    {
      path: "*",
      component: () => import("@/components/landing/pages/SignInPage.vue"),
    },
  ],
});

@Component({
  components: {
    LanguageSelector,
  },
  router,
  data: () => ({ IMAGE_RAW_URL, window }),
})
export default class LandingPageVue extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @InjectReactive(APPLICATION)
  application!: ApplicationDetails;

  fetching = true;

  landingPage: LandingPage | null = null;

  height = window.innerHeight;
  width = window.innerWidth;

  mounted(): void {
    this.fetch();
  }

  onResize() {
    this.height = window.innerHeight;
    this.width = window.innerWidth;
  }

  async fetch(): Promise<void> {
    this.fetching = true;

    try {
      this.landingPage = await this.landingPageService.getCurrent();
    } finally {
      this.fetching = false;
    }
  }

  get landingPageService(): ILandingPageService {
    return this.container.resolve<ILandingPageService>(S.LANDINGPAGESERVICE);
  }
}
</script>

<style>
.landing-background {
  height: 100vh;
  width: 100%;
  background: linear-gradient(#83828277, #9198e573);
}
</style>